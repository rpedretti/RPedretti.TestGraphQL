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
    public class ProductQueryQueryBuilder : GraphQlQueryBuilder<ProductQueryQueryBuilder>
    {
        private static readonly FieldMetadata[] AllFieldMetadata =
        {
            new FieldMetadata { Name = "products", IsComplex = true, QueryBuilderType = typeof(ProductQueryBuilder) },
            new FieldMetadata { Name = "product", IsComplex = true, QueryBuilderType = typeof(ProductQueryBuilder) },
            new FieldMetadata { Name = "productTypes", IsComplex = true, QueryBuilderType = typeof(ProductTypeQueryBuilder) },
            new FieldMetadata { Name = "productType", IsComplex = true, QueryBuilderType = typeof(ProductTypeQueryBuilder) }
        };

        protected override string TypeName { get; } = "ProductQuery";

        public override IReadOnlyList<FieldMetadata> AllFields { get; } = AllFieldMetadata;

        public ProductQueryQueryBuilder(string? operationName = null) : base("query", operationName)
        {
        }

        public ProductQueryQueryBuilder WithParameter<T>(GraphQlQueryParameter<T> parameter) => WithParameterInternal(parameter);

        public ProductQueryQueryBuilder WithProducts(ProductQueryBuilder productQueryBuilder, string? alias = null, IncludeDirective? include = null, SkipDirective? skip = null) => WithObjectField("products", alias, productQueryBuilder, new GraphQlDirective?[] { include, skip });

        public ProductQueryQueryBuilder ExceptProducts() => ExceptField("products");

        public ProductQueryQueryBuilder WithProduct(ProductQueryBuilder productQueryBuilder, QueryBuilderParameter<int?>? productId = null, string? alias = null, IncludeDirective? include = null, SkipDirective? skip = null)
        {
            var args = new List<QueryBuilderArgumentInfo>();
            if (productId != null)
                args.Add(new QueryBuilderArgumentInfo { ArgumentName = "productId", ArgumentValue = productId} );

            return WithObjectField("product", alias, productQueryBuilder, new GraphQlDirective?[] { include, skip }, args);
        }

        public ProductQueryQueryBuilder ExceptProduct() => ExceptField("product");

        public ProductQueryQueryBuilder WithProductTypes(ProductTypeQueryBuilder productTypeQueryBuilder, string? alias = null, IncludeDirective? include = null, SkipDirective? skip = null) => WithObjectField("productTypes", alias, productTypeQueryBuilder, new GraphQlDirective?[] { include, skip });

        public ProductQueryQueryBuilder ExceptProductTypes() => ExceptField("productTypes");

        public ProductQueryQueryBuilder WithProductType(ProductTypeQueryBuilder productTypeQueryBuilder, QueryBuilderParameter<int?>? productTypeId = null, string? alias = null, IncludeDirective? include = null, SkipDirective? skip = null)
        {
            var args = new List<QueryBuilderArgumentInfo>();
            if (productTypeId != null)
                args.Add(new QueryBuilderArgumentInfo { ArgumentName = "productTypeId", ArgumentValue = productTypeId} );

            return WithObjectField("productType", alias, productTypeQueryBuilder, new GraphQlDirective?[] { include, skip }, args);
        }

        public ProductQueryQueryBuilder ExceptProductType() => ExceptField("productType");
    }
}
