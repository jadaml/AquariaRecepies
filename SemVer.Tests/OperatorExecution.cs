using System;
using System.Linq.Expressions;

namespace JAL.SemanticVersion.Tests
{
    public class OperatorExecution<T>
    {
        private Func<T, T, bool> operation;

        public string Display { get; }

        public OperatorExecution(Func<T, T, bool> operation, string display)
        {
            this.operation = operation;
            Display = display;
        }

        public OperatorExecution(Expression<Func<T, T, bool>> operationExpression)
        {
            operation = operationExpression.Compile();
            Display = operationExpression.Body.ToString();
        }

        public bool Invoke(T a, T b)
        {
            return operation(a, b);
        }

        public override string ToString()
        {
            return Display;
        }
    }
}
