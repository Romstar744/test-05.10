using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Model;

namespace WindowsFormsApp3
{
	internal static class Extensions
	{
		public static void AddBinding<TControl, TSource>(this TControl target,
			Expression<Func<TControl, object>> targetProperty,
			TSource source,
			Expression<Func<TSource, object>> sourceProperty)
			where TControl : Control
			where TSource : class
		{
			var targetName = GetMemberName(targetProperty);
			var sourceName = GetMemberName(sourceProperty);
			target.DataBindings.Add(new Binding(targetName, source, sourceName,
				false,
				DataSourceUpdateMode.OnPropertyChanged));

		}

		private static string GetMemberName<TItem, TMember>(Expression<Func<TItem, TMember>> targetMemeber)
		{
			if (targetMemeber.Body is MemberExpression memberExpression)
			{
				return memberExpression.Member.Name;
			}

			if (targetMemeber.Body is UnaryExpression unaryExpression) 
			
			{
				var operand = unaryExpression.Operand as MemberExpression;
				return operand.Member.Name;
			}

			throw new ArgumentException();
		}
	}
}
