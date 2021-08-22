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
    public class SkipDirective : GraphQlDirective
    {
        public SkipDirective(QueryBuilderParameter<bool> @if) : base("skip")
        {
            AddArgument("if", @if);
        }
    }
}
