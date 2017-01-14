namespace ConsoleWebServer.Framework
{
    using System.Linq;
    using System.Reflection;
    using ActionResults.Contracts;
    using Exceptions;

    public class ActionInvoker
    {
        private const string ExpectedMethodExceptionMessage = "Expected method with signature IActionResult {0}(string) in class {1}Controller";

        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            var methodWithIntParameter = controller
                                            .GetType()
                                            .GetMethods()
                                            .FirstOrDefault(x => x.Name.ToLower() == actionDescriptor.ActionName.ToLower() && x.GetParameters().Length == 1
                                                && x.GetParameters()[0].ParameterType == typeof(string) && x.ReturnType == typeof(IActionResult));
            if (methodWithIntParameter == null)
            {
                string message = string.Format(ExpectedMethodExceptionMessage, actionDescriptor.ActionName, actionDescriptor.ControllerName);
                throw new HttpNotFound(message);
            }

            try
            {
                var parameters = new object[] { actionDescriptor.Parameter };
                var actionResult = (IActionResult)methodWithIntParameter.Invoke(controller, parameters);

                return actionResult;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}