﻿using System.Linq;
using VocaDb.Model.Domain;
using VocaDb.Model.Domain.Tags;

namespace VocaDb.Model.Service.QueryableExtenders {

	public static class EntryWithTagsQueryableExtender {

		public static IQueryable<TEntry> WhereHasTag<TEntry, TTagLink>(this IQueryable<TEntry> query, string tagName) 
			where TEntry : IEntryWithTags<TTagLink> where TTagLink : TagUsage {

			if (string.IsNullOrEmpty(tagName))
				return query;

			return query.Where(s => s.Tags.Usages.Any(a => a.Tag.Name == tagName));

		}

		public static IQueryable<TEntry> WhereHasTags<TEntry, TTagLink>(this IQueryable<TEntry> query, string[] tagNames) 
			where TEntry : IEntryWithTags<TTagLink> where TTagLink : TagUsage {

			if (tagNames == null || !tagNames.Any())
				return query;

			return tagNames.Aggregate(query, WhereHasTag<TEntry, TTagLink>);

		}

	}

}
