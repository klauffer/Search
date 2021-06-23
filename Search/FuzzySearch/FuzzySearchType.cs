﻿namespace Search.FuzzySearch
{
    /// <summary>
    /// types of supported algorithms 
    /// </summary>
    public enum FuzzySearchType
    {
        /// <summary>
        /// Measure the distance between words with single character edits(insertions, deletions or substitutions)
        /// </summary>
        Levenshtein,
        /// <summary>
        /// Measure the distance between words consisting of insertions, deletions or substitutions of a single character, or transposition of two adjacent characters
        /// </summary>
        DamerauLevenshtein
    }
}
