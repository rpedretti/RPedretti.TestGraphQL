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
    public class ProductQueryBuilder : GraphQlQueryBuilder<ProductQueryBuilder>
    {
        private static readonly FieldMetadata[] AllFieldMetadata =
        {
            new FieldMetadata { Name = "productId" },
            new FieldMetadata { Name = "productName" },
            new FieldMetadata { Name = "productType", IsComplex = true, QueryBuilderType = typeof(ProductTypeQueryBuilder) }
        };

        protected override string TypeName { get; } = "Product";

        public override IReadOnlyList<FieldMetadata> AllFields { get; } = AllFieldMetadata;

        public ProductQueryBuilder WithProductId(string? alias = null, IncludeDirective? include = null, SkipDirective? skip = null) => WithScalarField("productId", alias, new GraphQlDirective?[] { include, skip });

        public ProductQueryBuilder ExceptProductId() => ExceptField("productId");

        public ProductQueryBuilder WithProductName(string? alias = null, IncludeDirective? include = null, SkipDirective? skip = null) => WithScalarField("productName", alias, new GraphQlDirective?[] { include, skip });

        public ProductQueryBuilder ExceptProductName() => ExceptField("productName");

        public ProductQueryBuilder WithProductType(ProductTypeQueryBuilder productTypeQueryBuilder, string? alias = null, IncludeDirective? include = null, SkipDirective? skip = null) => WithObjectField("productType", alias, productTypeQueryBuilder, new GraphQlDirective?[] { include, skip });

        public ProductQueryBuilder ExceptProductType() => ExceptField("productType");
    }
}
