using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace BinaryExpressionTree
{
    public class BinaryExpressionTreeClass : IBinaryExpressionTree
    {
        public string Infix { get; set; }
        public string Postfix { get; set; }
        public INode Root { get; set; }
        public BinaryExpressionTreeClass(string expr)
        {
            var expression = Regex.Replace(expr.Replace(" ", string.Empty), @"[+^\-*/()]", " $& ");
            expression = Regex.Replace(expression, @"cos|sin|tan|ctn|log|ex", " $& ");
            var postfix = ShuntingYardAlgorithm(expression);
            Stack<Node> st = new Stack<Node>();
            Node t, t1, t2; 
            for (int i = 0; i < postfix.Count; i++)
            { 
                if (IsNumber(postfix[i]))
                {
                    t = new Node(postfix[i]);
                    st.Push(t);
                }
                else
                {
                    t1 = st.Pop();
                    t2 = st.Pop();
                    t = new Node(postfix[i],t2,t1);   
                    st.Push(t);
                }
            }
            Root = st.Pop();
        }
        public double Calculate()
        {
            return Evaluate(Root);
        }
        private double Evaluate(INode node)
        {
            if (node == null)
                return 0;
            if (node.LeftChild==null&&node.RightChild==null)
                return Convert.ToDouble(node.Value);
            double leftValue = Evaluate(node.LeftChild);
            double rightValue = Evaluate(node.RightChild);
            if (node.Value == "+")
                return leftValue + rightValue; 
            if (node.Value == "-")
                return leftValue - rightValue; 
            if (node.Value == "*")
                return leftValue * rightValue;
            if (node.Value == "^")
                return Math.Pow(leftValue,rightValue); 
            return leftValue / rightValue;
        }
        private void InOrder(INode node)
        {
            if (node != null)
            {
                InOrder(node.LeftChild);
                Infix += node.Value;
                InOrder(node.RightChild);
            }
        }
        private void PostOrder(INode node)
        {
            if (node != null)
            {
                PostOrder(node.LeftChild);
                PostOrder(node.RightChild);
                Postfix+=node.Value;
            }
        }
        public string InOrderTraverse()
        {
            Infix = string.Empty;
            InOrder(Root);
            var result = Infix;
            Infix = string.Empty;
            result = Regex.Replace(result.Replace(" ", string.Empty), @"[+^\-*/()]", " $& ");
            result = Regex.Replace(result, @"cos|sin|tan|ctn|log|ex", " $& ");
            return result;
        }
        public string PostOrderTraverse()
        {
            Postfix = string.Empty;
            PostOrder(Root);
            var result = Postfix;
            Postfix = string.Empty;
            return result;
        }
        private List<string> ShuntingYardAlgorithm(string expr)
        {
            #region
            var expression = Regex.Replace(expr.Replace(" ", string.Empty), @"[+^\-*/()]", " $& ");
            expression = Regex.Replace(expression, @"cos|sin|tan|ctn|log|ex", " $& ");
            string[] tokens = expression.Split(null);
            List<string> output = new List<string>();
            Stack<string> operators = new Stack<string>();
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    case "(":
                        operators.Push(tokens[i]);
                        continue;
                    case "^":
                    case "*":
                    case "/":
                    case "+":
                    case "-":
                    case "sin":
                    case "tan":
                    case "ctn":
                    case "cos":
                    case "log":
                    case "ex":
                        while (operators.Count > 0 && Priority(tokens[i]) <= Priority(operators.Peek().ToString()))
                        {
                            output.Add(operators.Pop().ToString());
                        }
                        operators.Push(tokens[i]);
                        continue;
                    case ")":
                        while (operators.Peek() != "(")
                        {
                            output.Add(operators.Pop().ToString());
                        }
                        operators.Pop();
                        continue;
                }
                if (Regex.IsMatch(tokens[i].ToString(), @"[a-z]+$"))
                {
                    output.Add(tokens[i]);
                    continue;
                }
                if (IsNumber(tokens[i]) || tokens[i] == ".")
                {
                    output.Add(tokens[i]);
                    continue;
                }
            }
            while (operators.Any())
            {
                output.Add(operators.Pop().ToString());
            }
            return output;
            #endregion
        }
        private int Priority(string symbol)
        {
            #region
            if (symbol == "sin" || symbol == "cos" || symbol == "ctn" || symbol == "tan" || symbol == "log" || symbol == "ex")
            {
                return 5;
            }
            else if (symbol == "^")
            {
                return 4;
            }
            else if (symbol == "*" || symbol == "/")
            {
                return 3;
            }
            else if (symbol == "+" || symbol == "-")
            {
                return 2;
            }
            else if (symbol == "(")
            {
                return 1;
            }
            else
            {
                return -1;
            }
            #endregion
        }
        private bool IsNumber(string n)
        {
            double retNum;
            bool isNumeric = double.TryParse(n, out retNum);
            return isNumeric;
        }
    }
}
