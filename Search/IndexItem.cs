﻿using System.Collections.Generic;
using Search.Infrastructure;

namespace Search
{
    /// <summary>
    /// Represents a single record that is being searched for
    /// </summary>
    public sealed class IndexItem : ValueObject
    {
        /// <summary>
        /// Instantiates an IdexItem with the required fields to make this object immutable
        /// </summary>
        /// <param name="phraseId">a uniquely identifying value</param>
        /// <param name="phrase">the string that is being searched</param>
        public IndexItem(string phraseId, string phrase)
        {
            PhraseId = phraseId;
            Phrase = phrase;
        }

        /// <summary>
        /// a uniquely identifying value
        /// </summary>
        public string PhraseId { get; }

        /// <summary>
        /// the string that is being searched
        /// </summary>
        public string Phrase { get; set; }

        ///<inheritdoc/>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PhraseId;
        }
    }
}
