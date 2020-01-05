namespace VocaDb.Model.Domain.Tags {

	public class EntryTypeToTagMapping {

		public virtual EntryType EntryType { get; set; }

		public virtual EntryTypeAndSubType EntryTypeAndSubType => new EntryTypeAndSubType(EntryType, SubType);

		public virtual int Id { get; set; }

		/// <summary>
		/// Entry subtype, such as <see cref="SongType.Remix"/>.
		/// </summary>
		public virtual string SubType { get; set; }

		public virtual Tag Tag { get; set; }

	}

}