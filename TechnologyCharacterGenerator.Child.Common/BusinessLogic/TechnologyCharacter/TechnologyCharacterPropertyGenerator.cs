using System;
using System.Linq.Expressions;
using System.Reflection;
using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class TechnologyCharacterPropertyGenerator<TProperty> : ITechnologyCharacterPropertyGenerator
    {
        public TechnologyCharacterPropertyGenerator(ushort userhashIndex,
            Expression<Func<TechnologyCharacterViewModel, TProperty>> propertyExpression,
            Func<ushort, TProperty> convertHashValueToPropertyValue)
        {
            UserHashIndex = userhashIndex;
            PropertyExpression = propertyExpression;
            ConvertHashValueToPropertyValue = convertHashValueToPropertyValue;
        }

        public ushort UserHashIndex { get; }

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel,
            ushort userHashValue, UserViewModel userViewModel)
        {
            var value = ConvertHashValueToPropertyValue(userHashValue);

            if (PropertyExpression.Body is MemberExpression memberSelectorExpression)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(technologyCharacterViewModel, value, null);
                }
            }
        }

        private Expression<Func<TechnologyCharacterViewModel, TProperty>> PropertyExpression { get; }

        private Func<ushort, TProperty> ConvertHashValueToPropertyValue { get; }
    }
}