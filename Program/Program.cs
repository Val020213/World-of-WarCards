﻿using AST;
using GameProgram;
using Compiler;

static class Program
{
    static void Main(string[] args)
    {
        Expression Sum = new Add(new Number(1, new CodeLocation()), new Number(2, new CodeLocation()), new CodeLocation());
        Expression Div = new Div(new Number(1, new CodeLocation()), new Number(2, new CodeLocation()), new CodeLocation());
        //System.Console.WriteLine(Div.CheckSemantic(new List<Error>()));
        Expression Greater = new GreaterThan(Sum, Div, new CodeLocation());
        Expression Smaller = new SmallerThan(Sum, Div, new CodeLocation());

        Expression Addcorner = new Add(Sum, Sum, new CodeLocation());

        Greater.Evaluate();
        Smaller.Evaluate();

        Expression AndExpression = new And(Greater, Smaller, new CodeLocation());
        Expression OrExpression = new Or(Greater, Smaller, new CodeLocation());

        AndExpression.Evaluate();
        OrExpression.Evaluate();

        Console.WriteLine($"{Greater.Value} {Smaller.Value} {AndExpression.Value} {OrExpression.Value}");

        Expression NotExpression = new Not(Greater, new CodeLocation());
        NotExpression.Evaluate();
        Console.WriteLine(NotExpression.Value);

        Effector Effect = new Effector(new List<Objective> { new Self(new CodeLocation()) }, new List<Power> { new ModifyHealth(Addcorner, new CodeLocation()) }, new CodeLocation());

        Effect.Evaluate();

        //Val's working

        string randomInput = "uno dos tres probando 5 + 6 1-2 1*2 = -1 1.2 -1.2";
        List<Error> tempErros = new List<Error>();
        List<Token> tokens = Analyzer.GetTokens("", randomInput, tempErros);

        foreach(var token in tokens)
        {
            Console.WriteLine(token.ToString());
        }
        foreach(var error in tempErros)
        {
            Console.WriteLine(error.ToString());
        }


    }
}
