using beqom.Domain.Aggregate;
using beqom.Domain.Aggregate.Option;
using System;
using Xunit;

namespace beqom.Test.Aggregate
{
    public class OptionTest
    {
        [Fact]
        public void Empty_Option_Has_No_Value()
        {
            Assert.False(Option.Empty<EmptyOption>() != null);
        }

        [Fact]
        public void Default_Option_IsEmpty()
        {
            DefaultOption defaultOption = new Option<DefaultOption>(new DefaultOption()).FromValue();
            Assert.Equal(Option.Empty<DefaultOption>().Id, defaultOption.Id);
            Assert.Equal(Option.Empty<DefaultOption>().Name, defaultOption.Name);
            Assert.Equal(Option.Empty<DefaultOption>().Status, defaultOption.Status);
            Assert.Equal(Option.Empty<DefaultOption>().IsActive, defaultOption.IsActive);
            Assert.IsType<Option>(Option.Empty<Option>());
            Assert.Equal(typeof(Option), Option.Empty<DefaultOption>().GetType());
        }

        [Fact]
        public void Non_Empty_Option_Has_Value()
        {
            Assert.True(new Option<NonEmptyOption>(new NonEmptyOption()).FromValue().GetValue(typeof(NonEmptyOption).Name).HasValue());
        }

        [Fact]
        public void Empty_Option_Value_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => Option.Empty<NonEmptyOption>());
        }

        [Fact]
        public void Non_Empty_Option_Returns_Its_Value()
        {
            var value = new Option<NonEmptyOption>(new NonEmptyOption()).FromValue();
            Assert.True(value.IsSame(new Option<NonEmptyOption>(new NonEmptyOption()).FromValue()));
        }

        [Fact]
        public void Comparison_Is_Correct_If_Not_Empty()
        {
            var value = new Option<NonEmptyOption>(new NonEmptyOption()).FromValue().GetValue(typeof(NonEmptyOption).Name);
            Assert.True(new Option<NonEmptyOption>(new NonEmptyOption()).FromValue().GetValue(typeof(NonEmptyOption).Name).IsSame(new Option<NonEmptyOption>(new NonEmptyOption()).FromValue().GetValue(typeof(NonEmptyOption).Name)));
            Assert.True(new Option<NonEmptyOption>(new NonEmptyOption()).FromValue().GetType() == new Option<NonEmptyOption>(new NonEmptyOption()).FromValue().GetType());
            Assert.False(new Option<NonEmptyOption>(new NonEmptyOption()).FromValue().GetValue(typeof(NonEmptyOption).Name) == Option.Empty<EmptyOption>());
        }

        [Fact]
        public void Empty_Option_ValueOr_Evaluates_Else_Branch()
        {
            var expected = Option.Empty<EmptyOption>();
            Assert.Same(expected, Option.Empty<EmptyOption>().ValueOr(() => expected));
        }

        [Fact]
        public void Empty_Option_Select_Returns_Empty()
        {
            var result = Option.Empty<EmptyOption>().Select(v => v);
            Assert.True(result == Option.Empty<EmptyOption>());
        }

        [Fact]
        public void Non_Empty_Option_Select_Returns_ExpectedType()
        {
            var result = new Option<NonEmptyOption>(new NonEmptyOption()).FromValue().Select(v => v).GetType();
            Assert.True(result == new Option<NonEmptyOption>(new NonEmptyOption()).FromValue().GetType());
        }

        [Fact]
        public void Non_Empty_Option_ValueOr_Does_Not_Evaluate_Else_Branch()
        {
            var value = new object();
            var option = new Option<object>(new object()).FromValue();
            Func<EmptyOption> fct = () =>
            {
                // we will break on purpose here.
                Assert.True(false);
                return null;
            };
            Assert.Same(value.GetType(), option.ValueOr(fct).GetType());
        }
    }
}