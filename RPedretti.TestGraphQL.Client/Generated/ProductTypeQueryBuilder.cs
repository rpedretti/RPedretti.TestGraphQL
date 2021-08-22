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
    public class ProductTypeQueryBuilder : GraphQlQueryBuilder<ProductTypeQueryBuilder>
    {
        private static readonly FieldMetadata[] AllFieldMetadata =
        {
            new FieldMetadata { Name = "productTypeId" },
            new FieldMetadata { Name = "productTypeName" }
        };

        protected override string TypeName { get; } = "ProductType";

        public override IReadOnlyList<FieldMetadata> AllFields { get; } = AllFieldMetadata;

        public ProductTypeQueryBuilder WithProductTypeId(string? alias = null, IncludeDirective? include = null, SkipDirective? skip = null) => WithScalarField("productTypeId", alias, new GraphQlDirective?[] { include, skip });

        public ProductTypeQueryBuilder ExceptProductTypeId() => ExceptField("productTypeId");

        public ProductTypeQueryBuilder WithProductTypeName(string? alias = null, IncludeDirective? include = null, SkipDirective? skip = null) => WithScalarField("productTypeName", alias, new GraphQlDirective?[] { include, skip });

        public ProductTypeQueryBuilder ExceptProductTypeName() => ExceptField("productTypeName");
    }
}
