using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tuna.Revit.Extension;

public class ParameterFilterProvider
{
    private readonly Document _document;

    public ParameterFilterProvider(Document document)
    {
        _document = document;
        FilterRules = new List<FilterRule>();
    }

    public List<FilterRule> FilterRules { get; set; }

    public ParameterFilterProvider OfCategories(params BuiltInCategory[] builtInCategory)
    {
     
        return this;
    }

    public ParameterFilterProvider WithParameterStringValue(BuiltInParameter builtInParameter, ParameterFilterStringOperator stringOperator, string value)
    {
     
      
        return this;
    }

    public FilteredElementCollector ToFilter()
    {
        if (FilterRules.Count == 0)
        {
            throw new ArgumentException("not filter rule");
        }

        if (FilterRules.Count == 1)
        {
            return _document.GetElements(new ElementParameterFilter(FilterRules.First()));
        }

        return _document.GetElements(new ElementParameterFilter(FilterRules));
    }
}
