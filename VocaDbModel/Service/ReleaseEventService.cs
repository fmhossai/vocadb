﻿using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using VocaDb.Model.Database.Repositories.NHibernate;
using VocaDb.Model.Domain.Security;
using VocaDb.Model.DataContracts.ReleaseEvents;
using VocaDb.Model.Domain.Albums;
using VocaDb.Model.Service.Search;

namespace VocaDb.Model.Service {

	public class ReleaseEventService : ServiceBase {

		public ReleaseEventService(ISessionFactory sessionFactory, IUserPermissionContext permissionContext, IEntryLinkFactory entryLinkFactory) 
			: base(sessionFactory, permissionContext,entryLinkFactory) {}

		public void DeleteSeries(int id) {

			DeleteEntity<ReleaseEventSeries>(id, PermissionToken.ManageEventSeries);

		}

		public ReleaseEventFindResultContract Find(string query) {

			if (string.IsNullOrEmpty(query))
				return new ReleaseEventFindResultContract();

			query = query.Trim().Normalize(NormalizationForm.FormKC);	// Replaces fullwidth characters with ASCII

			return HandleQuery(session => {

				return new ReleaseEventSearch(new NHibernateDatabaseContext(session, PermissionContext)).Find(query);

			});

		}

		public ReleaseEventSeriesWithEventsContract[] GetReleaseEventsBySeries() {

			return HandleQuery(session => {

				var allEvents = session.Query<ReleaseEvent>().ToArray();
				var series = session.Query<ReleaseEventSeries>().OrderBy(e => e.Name).ToArray();

				var seriesContracts = series.Select(s => 
					new ReleaseEventSeriesWithEventsContract(s, allEvents.Where(e => s.Equals(e.Series)), PermissionContext.LanguagePreference));
				var ungrouped = allEvents.Where(e => e.Series == null).OrderBy(e => e.Name);

				return seriesContracts.Concat(new[] { new ReleaseEventSeriesWithEventsContract { 
					Name = string.Empty, 
					Events = ungrouped.Select(e => new ReleaseEventContract(e)).ToArray() } }).ToArray();

			});

		}

		public ReleaseEventDetailsContract GetReleaseEventDetails(int id) {

			return HandleQuery(session => new ReleaseEventDetailsContract(session.Load<ReleaseEvent>(id), PermissionContext.LanguagePreference));

		}

		public ReleaseEventDetailsContract GetReleaseEventForEdit(int id) {

			return HandleQuery(session => new ReleaseEventDetailsContract(
				session.Load<ReleaseEvent>(id), PermissionContext.LanguagePreference) {
					AllSeries = session.Query<ReleaseEventSeries>().Select(s => new ReleaseEventSeriesContract(s)).ToArray()
				});

		}

		public ReleaseEventWithArchivedVersionsContract GetReleaseEventWithArchivedVersions(int id) {

			return HandleQuery(session =>
				new ReleaseEventWithArchivedVersionsContract(session.Load<ReleaseEvent>(id)));

		}

		public ReleaseEventSeriesDetailsContract GetReleaseEventSeriesDetails(int id) {

			return HandleQuery(session => new ReleaseEventSeriesDetailsContract(session.Load<ReleaseEventSeries>(id), PermissionContext.LanguagePreference));

		}

		public ReleaseEventSeriesForEditContract GetReleaseEventSeriesForEdit(int id) {

			return HandleQuery(session => new ReleaseEventSeriesForEditContract(session.Load<ReleaseEventSeries>(id)));

		}

	}

}
