using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AST
{
    public class Not : UnaryExpression
    {
        public Not(Expression argument, CodeLocation location) : base(argument, location) { Value = false; }
        public override NodeType Type { get => NodeType.Bool; set { } }
        public override string OperationSymbol => "!";
        public override object Value { get; set; }
        public override Func<Expression, bool> IsValid => (e) => e.Type == NodeType.Bool;

        public override void Evaluate()
        {
            Argument.Evaluate();
            Value = !(bool)Argument.Value;
        }

    }
}