using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Collection.ParameterFilter;

/// <summary>
/// 
/// </summary>
public  class ParameterFilter
{
    internal List<FilterRule> FilterRules { get; }

    /// <summary>
    /// 
    /// </summary>
    protected ParameterFilter()
    {
        FilterRules = new List<FilterRule>();
    }

    /// <summary>
    /// 
    /// </summary>
    public static ParameterFilter OfCategories()
    {
      return new ParameterFilter();
    }

    public void Parameter()
    {
        //ParameterFilter.OfCategories().Parameter().E
    }

    public sealed class Equals : ParameterFilter
    {
        public Equals(ElementId parameterId, string value)
        {
            FilterRule filterRule = ParameterFilterRuleFactory.CreateEqualsRule(parameterId, value);
            FilterRules.Add(filterRule);
        }

        public Equals(ElementId parameterId, double value, double epsilon = 0.1)
        {
            FilterRule filterRule = ParameterFilterRuleFactory.CreateEqualsRule(parameterId, value, epsilon);
            FilterRules.Add(filterRule);
        }

        public Equals(ElementId parameterId, int value)
        {
            FilterRule filterRule = ParameterFilterRuleFactory.CreateEqualsRule(parameterId, value);
            FilterRules.Add(filterRule);
        }

        public Equals(ElementId parameterId, ElementId value)
        {
            FilterRule filterRule = ParameterFilterRuleFactory.CreateEqualsRule(parameterId, value);
            FilterRules.Add(filterRule);
        }
    }
}
