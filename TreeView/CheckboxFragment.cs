﻿using Microsoft.AspNetCore.Components;
using System;

namespace Excubo.Blazor.TreeViews
{
    public delegate RenderFragment CheckboxFragment(bool value, bool indeterminate, Action<bool> value_changed, bool disabled);
    public delegate RenderFragment CheckboxFragment2(bool value, bool indeterminate, Action<bool> value_changed, Action<bool> indeterminate_changed, bool disabled);
    public static class CheckboxFragmentConverter
    {
        public static CheckboxFragment ToCheckboxFragment(this CheckboxFragment2 fragment)
        {
            return (value, indeterminate, value_changed, disabled) =>
            {
                return (builder) =>
                {
                    builder.AddContent(0, fragment(value == true, indeterminate, (v) => value_changed(v), (v) => { }, disabled));
                };
            };
        }
    }
}