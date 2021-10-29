﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

#if EFCORE2
using Microsoft.EntityFrameworkCore.Internal;
#endif

namespace ShardingCore.Core.EntityMetadatas
{
    public class EntityMetadataDataSourceBuilder<TEntity> where TEntity : class
    {
        private readonly EntityMetadata _entityMetadata;

        private EntityMetadataDataSourceBuilder(EntityMetadata entityMetadata)
        {
            _entityMetadata = entityMetadata;
        }
        /// <summary>
        /// 设置分表字段
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        public EntityMetadataDataSourceBuilder<TEntity> ShardingProperty<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            var propertyAccess = propertyExpression.GetPropertyAccess();
            _entityMetadata.SetShardingTableProperty(propertyAccess);
            return this;
        }
        public EntityMetadataDataSourceBuilder<TEntity> ShardingProperty(string propertyName)
        {
            var propertyInfo = typeof(TEntity).GetProperty(propertyName);
            _entityMetadata.SetShardingTableProperty(propertyInfo);
            return this;
        }
        /// <summary>
        /// 是否启动建表
        /// </summary>
        /// <param name="autoCreate"></param>
        /// <returns></returns>
        public EntityMetadataDataSourceBuilder<TEntity> AutoCreateDataSource(bool? autoCreate)
        {
            _entityMetadata.AutoCreateDataSourceTable = autoCreate;
            return this;
        }


        public static EntityMetadataDataSourceBuilder<TEntity> CreatEntityMetadataDataSourceBuilder(EntityMetadata entityMetadata)
        {
            return new EntityMetadataDataSourceBuilder<TEntity>(entityMetadata);
        }

    }
}