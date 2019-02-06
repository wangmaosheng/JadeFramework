using System;
using System.Linq;
using System.Linq.Expressions;

namespace JadeFramework.Core.Linq
{
    /// <summary>
    /// 动态表达式帮助类
    /// </summary>
    public static class ExpressionHelper
    {
        /// <summary>
        /// Creates a predicate that evaluates to true.
        /// </summary>
        public static Expression<Func<T, bool>> True<T>() { return param => true; }

        /// <summary>
        /// Creates a predicate that evaluates to false.
        /// </summary>
        public static Expression<Func<T, bool>> False<T>() { return param => false; }

        /// <summary>
        /// Creates a predicate expression from the specified lambda expression.
        /// </summary>
        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate) { return predicate; }

        /// <summary>
        /// Combines the first predicate with the second using the logical "and".
        /// </summary>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>
        /// Combines the first predicate with the second using the logical "or".
        /// </summary>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        /// <summary>
        /// Negates the predicate.
        /// </summary>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }

        /// <summary>
        /// Combines the first expression with the second using the specified merge function.
        /// </summary>
        static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)
            var map = first.Parameters
                .Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // create a merged lambda expression with parameters from the first expression
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }




        //public static string GetWhereClause<T>(Expression<Func<T, bool>> expression)
        //{
        //    return GetValueAsString(expression.Body);
        //}

        //public static string GetValueAsString(Expression expression)
        //{
        //    var value = "";//结果
        //    var equalty = GetNodeTypeValue(expression.NodeType);
        //    var left = GetLeftNode(expression);
        //    var right = GetRightNode(expression);
        //    if (left is MemberExpression)
        //    {
        //        var leftMem = left as MemberExpression;
        //        value = string.Format("({0}{1}{2})", leftMem.Member.Name, equalty, "{0}");
        //    }
        //    if (right is ConstantExpression)
        //    {
        //        var rightConst = right as ConstantExpression;
        //        string str = GetRightValue(rightConst);
        //        value = string.Format(value, str);
        //    }
        //    if (right is MemberExpression)
        //    {
        //        var rightMem = right as MemberExpression;
        //        var rightConst = rightMem.Expression as ConstantExpression;
        //        var member = rightMem.Member.DeclaringType;
        //        //var type = rightMem.Member.MemberType;
        //        var val = member.GetField(rightMem.Member.Name).GetValue(rightConst.Value);
        //        value = string.Format(value, val);
        //    }
        //    if (value == "")
        //    {
        //        var leftVal = GetValueAsString(left);
        //        var rigthVal = GetValueAsString(right);
        //        value = string.Format("({0} {1} {2})", leftVal, equalty, rigthVal);
        //    }
        //    return value;
        //}
        //private static Expression GetLeftNode(Expression expression)
        //{
        //    //dynamic exp = expression;
        //    //return (Expression)exp.Left;

        //    dynamic exp = expression;
        //    var res = exp.Left as Expression;

        //    return res;
        //}

        //private static Expression GetRightNode(Expression expression)
        //{
        //    dynamic exp = expression;
        //    return (Expression)exp.Right;
        //}
        //private static string GetNodeTypeValue(ExpressionType expressionType)
        //{
        //    string equalty;
        //    switch (expressionType)
        //    {
        //        case ExpressionType.Equal:      //等于
        //        case ExpressionType.Constant:
        //            equalty = " = ";
        //            break;
        //        case ExpressionType.AndAlso:
        //            equalty = " AND ";
        //            break;
        //        case ExpressionType.NotEqual:   //不等于
        //            equalty = " <> ";
        //            break;
        //        case ExpressionType.OrElse:     //或者
        //            equalty = " OR ";
        //            break;
        //        case ExpressionType.GreaterThan://大于
        //            equalty = " > ";
        //            break;
        //        case ExpressionType.LessThan:   //小于
        //            equalty = " < ";
        //            break;
        //        default:
        //            equalty = " = ";
        //            break;
        //    }
        //    return equalty;
        //}

        ///// <summary>
        ///// 获取右值
        ///// </summary>
        ///// <param name="right"></param>
        ///// <returns></returns>
        //private static string GetRightValue(ConstantExpression right)
        //{
        //    if (right.Type == typeof(int) || right.Type == typeof(long) || right.Type == typeof(byte) || right.Type == typeof(sbyte))
        //    {
        //        return right.Value.ToString();
        //    }
        //    else if (right.Type == typeof(string) || right.Type == typeof(DateTime))
        //    {
        //        return $"'{right.Value}'";
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
    }
}
