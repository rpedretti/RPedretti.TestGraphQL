using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
#if!GRAPHQL_GENERATOR_DISABLE_NEWTONSOFT_JSON
using Newtonsoft.Json;
#endif

namespace RPedretti.TestGraphQL.Client
{
    public class IncludeDirective : GraphQlDirective
    {
        public IncludeDirective(QueryBuilderParameter<bool> @if) : base("include")
        {
            AddArgument("if", @if);
        }
    }
}
