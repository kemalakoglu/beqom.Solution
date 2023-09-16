using beqom.Domain.Aggregate;
using beqom.Domain.Aggregate.Option;
using beqom.Domain.Aggregate.Option.Entities;
using beqom.Domain.Contract.Interface;
using beqom.Domain.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace beqom.Test.Presentation
{
    public class OptionTest
    {
        private readonly IOptionRepository optionRepository;


        public OptionTest()
        {
            this.optionRepository = new OptionRepository();
        }

        [Fact]
        public void Empty_Option_Has_No_Value()
        {
            Assert.False(Option.Empty<EmptyOption>() != null);
        }

        [Fact]
        public void Default_Option_IsEmpty()
        {
            Option defaultOption = new Option();
            Assert.Equal(Option.Empty<Option>().Id, defaultOption.Id);
            Assert.Equal(Option.Empty<Option>().Name, defaultOption.Name);
            Assert.Equal(Option.Empty<Option>().Status, defaultOption.Status);
            Assert.Equal(Option.Empty<Option>().IsActive, defaultOption.IsActive);
            Assert.IsType<Option>(Option.Empty<Option>());
            Assert.Equal(typeof(Option), Option.Empty<Option>().GetType());
        }

        [Fact]
        public void Non_Empty_Option_Has_Value()
        {
            Assert.True(new Option<ConfigOption>().FromValue().HasValue());
        }

        [Fact]
        public void Empty_Option_Value_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => Option.Empty<ConfigOption>());
        }

        [Fact]
        public void Non_Empty_Option_Returns_Its_Value()
        {
            var value = new Option<ConfigOption>().FromValue();
            Assert.True(value.IsSame(new Option<ConfigOption>().FromValue()));
        }

        [Fact]
        public void Comparison_Is_Correct_If_Not_Empty()
        {
            var value = new Option<ConfigOption>().FromValue();
            Assert.True(new Option<ConfigOption>().FromValue().IsSame(new Option<ConfigOption>().FromValue()));
            Assert.True(new Option<ConfigOption>().FromValue().GetType() == new Option<ConfigOption>().FromValue().GetType());
            Assert.False(new Option<ConfigOption>().FromValue() == Option.Empty<EmptyOption>());
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
            var result = new Option<ConfigOption>().FromValue().Select(v => v).GetType();
            Assert.True(result == new Option<ConfigOption>().FromValue().GetType());
        }

        [Fact]
        public void Non_Empty_Option_ValueOr_Does_Not_Evaluate_Else_Branch()
        {
            var value = new object();
            var option = new Option<object>().FromValue() ?? new object();
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