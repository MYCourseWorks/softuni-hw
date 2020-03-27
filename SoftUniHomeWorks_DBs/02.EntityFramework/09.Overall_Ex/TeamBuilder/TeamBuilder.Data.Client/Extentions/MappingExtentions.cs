using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq.Expressions;

namespace TeamBuilder.Data.Client.Extentions
{
    public static class MappingExtentions
    {
        public static PrimitivePropertyConfiguration IsUnique(this PrimitivePropertyConfiguration configuration, string constraintName = null)
        {
            return configuration.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_" + constraintName) { IsUnique = true }));
        }
    }
}
