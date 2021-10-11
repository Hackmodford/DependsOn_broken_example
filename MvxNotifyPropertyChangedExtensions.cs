using System;
using System.Linq.Expressions;
using MvvmCross.ViewModels;
using ReactiveUI;

namespace NPCDemoBug1
{
    public static class MvxNotifyPropertyChangedExtensions
    {
        public static IDisposable ToPropertyChanged<TSender, TParent, TRet, TRet2>(
            this IObservable<IObservedChange<TSender, TRet>> changeObservable,
            TParent owner,
            Expression<Func<TParent, TRet2>> parentProperty) where TParent : MvxNotifyPropertyChanged
        {
            return changeObservable.Subscribe(value =>
            {
                var expression = (MemberExpression)parentProperty.Body;
                var name = expression.Member.Name;
                owner.RaisePropertyChanged(name);
            });
        }
    }
}