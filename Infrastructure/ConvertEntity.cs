using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ConvertEntity
    {
        //public static void ConvertEntityToItemsItem(object entity,ref Schema schema) 
        //{
        //    if (entity != null)
        //    {
        //        schema = new Schema();
        //        //获取类名
        //        schema.Code = entity.ToString().Split('.')[entity.ToString().Split('.').Length-1];

        //        System.Reflection.MemberInfo[] memberInfot =  entity.GetType().GetMembers();
        //        foreach (MemberInfo var in memberInfot)
        //        {
        //            if (var.MemberType == MemberTypes.Property)
        //            {
        //                System.Reflection.PropertyInfo propertyInfo = entity.GetType().GetProperty(var.Name);
                       
        //                string DisplayName = string.Empty;
        //                DescriptionAttribute[] arrDesc = (DescriptionAttribute[])var.GetCustomAttributes(typeof(DescriptionAttribute), false);
        //                if (arrDesc.Length > 0)
        //                {
        //                    DisplayName = arrDesc[0].Description;
        //                }
        //                if (entity.GetType().BaseType.Name == "object") 
        //                {
        //                    object val = propertyInfo.GetValue(entity, null);//属性值
        //                    var childSchema = new ChildSchema();
        //                    childSchema.Code = propertyInfo.Name + "objetc";
        //                   // foreach (var obj in entity.GetType())
        //                    childSchema.Items.Add(new ItemsItem { 
                                
        //                    });
        //                    schema.Items.Add(new ItemsItem
        //                    {
        //                        Name = propertyInfo.Name,//属性名称
        //                        DisplayName = DisplayName,//属性显示名称
        //                        DataType = propertyInfo.GetMethod.ReturnType.Name,//属性类型名称
        //                        //ChildSchema = 
        //                    });
        //                }
        //                else
        //                {
        //                    schema.Items.Add(new ItemsItem
        //                    {
        //                        Name = propertyInfo.Name,//属性名称
        //                        DisplayName = DisplayName,//属性显示名称
        //                        DataType = propertyInfo.GetMethod.ReturnType.Name//属性类型名称
        //                    });
        //                }

        //            }
        //        }
        //    }
        //}

    }

}
