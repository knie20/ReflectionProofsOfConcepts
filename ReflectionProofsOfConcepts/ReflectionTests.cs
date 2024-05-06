using ReflectionProofsOfConcepts.Models;
using System.Dynamic;

namespace ReflectionProofsOfConcepts
{
    public class UnitTest1
    {
        [Fact]
        public void Reflection_Should_GetNamedProps()
        {
            var objWithNamedProps = new ObjWithNamedProps
            {
                Name = "Knie",
                Description = "Knie is a name"
            };

            var consumingObj = new ConsumingObj
            {
                innerObj = objWithNamedProps
            };

            var props = consumingObj.innerObj.GetType().GetProperties();
            var type = consumingObj.innerObj.GetType();

            Assert.Equal("ObjWithNamedProps", type.Name);
            Assert.Equal(2, props.Length);
            Assert.Equal("Knie", props.Where(p => p.Name == "Name").FirstOrDefault()!.GetValue(consumingObj.innerObj));
            Assert.Equal("Knie is a name", props.Where(p => p.Name == "Description").FirstOrDefault()!.GetValue(consumingObj.innerObj));
        }
        [Fact]
        public void Reflection_Should_GetAttributedProps()
        {
            var objWithAttributedProps = new ObjWithAttributedProps
            {
                Name = "Knie",
                Description = "Knie is a name"
            };

            var consumingObj = new ConsumingObj
            {
                innerObj = objWithAttributedProps
            };

            var props = consumingObj.innerObj.GetType().GetProperties();
            var attr0 = props[0].GetCustomAttributes(true);
            var attr1 = props[1].GetCustomAttributes(true);

            Assert.Equal("DisplayNameAttribute", attr0[0].GetType().Name);
            Assert.Equal("BindableAttribute", attr1[0].GetType().Name);
        }

        [Fact]
        public void Reflection_Should_GetListProp()
        {
            var objWithList = new ObjWithList
            {
                Names = new List<string> { "Knie", "JMSale" }
            };
            var consumingObj = new ConsumingObj
            {
                innerObj = objWithList
            };

            var props = consumingObj.innerObj.GetType().GetProperties();
            var type = consumingObj.innerObj.GetType();

            Assert.Equal("Knie", (props[0].GetValue(consumingObj.innerObj) as List<string>)![0]);
        }

        [Fact]
        public void Reflection_Expando()
        {
            var objWithNamedProps = new ObjWithNamedProps
            {
                Name = "Knie",
                Description = "Knie is a name"
            };
            var expandoConsumer = new ExpandoObject() as IDictionary<string, object>;
            expandoConsumer["TestObject"] = objWithNamedProps;

            var fields = expandoConsumer["TestObject"].GetType().GetFields();
            var props = expandoConsumer["TestObject"].GetType().GetProperties();

            var fields1 = expandoConsumer.GetType().GetFields();
            var props1 = expandoConsumer.GetType().GetProperties();

            Assert.Equal("ObjWithNamedProps", expandoConsumer["TestObject"].GetType().Name);
        }
    }
}