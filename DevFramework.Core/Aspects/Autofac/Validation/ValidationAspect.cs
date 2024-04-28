using Castle.DynamicProxy;
using DevFramework.Core.CrossCuttingConcerns.FluentValidation;
using DevFramework.Core.Utilities.Interceptors;
using FluentValidation;

namespace DevFramework.Core.Aspects.Autofac.Validation
{
	public class ValidationAspect : MethodInterception
	{
		private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
			if (!typeof(IValidator).IsAssignableFrom(validatorType))
			{
				throw new System.Exception($"There is no validator such as {validatorType.Name}");
			}
			_validatorType = validatorType;
        }

		public override void OnBefore(IInvocation invocation)
		{
			var validator = (IValidator)Activator.CreateInstance(_validatorType);
			var entityType = _validatorType.BaseType.GetGenericArguments()[0];
			var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

			foreach (var entity in entities)
			{
				ValidationTool.Validate(validator, entity);	
			}
		}
	}
}
