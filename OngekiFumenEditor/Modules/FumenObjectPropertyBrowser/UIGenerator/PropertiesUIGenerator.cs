﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OngekiFumenEditor.Modules.FumenObjectPropertyBrowser.UIGenerator
{
    public class PropertiesUIGenerator
    {
        public static UIElement GenerateUI(PropertyInfoWrapper wrapper)
        {
            var typeGenerators = IoC.GetAll<ITypeUIGenerator>();
            return typeGenerators
                .Where(x =>
                    x.SupportTypes.Contains(wrapper.PropertyInfo.PropertyType) ||
                    x.SupportTypes.Any(x => wrapper.PropertyInfo.PropertyType.IsSubclassOf(x))
                    )
                .Select(x =>
                {
                    try
                    {
                        return x.Generate(wrapper);
                    }
                    catch (Exception e)
                    {
                        //todo
                        throw;
                    }
                }).OfType<UIElement>().FirstOrDefault();
        }
    }
}
