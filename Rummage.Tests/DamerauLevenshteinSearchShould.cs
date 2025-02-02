﻿using System.Linq;
using System.Threading.Tasks;
using Rummage.FuzzySearch;
using Rummage.Tests.TestHelpers;
using Xunit;

namespace Rummage.Tests
{
    public sealed class DamerauLevenshteinSearchShould : TestFixture
    {

        public DamerauLevenshteinSearchShould() : base(FuzzySearchType.DamerauLevenshtein)
        { 
        }

        [Fact]
        public async Task FindExactMatch()
        {
            var searchResult = await _searchEngine.Search("Homer Simpson", LocalData);
            var expectedPhraseId = PhraseId<int>.From(1);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == expectedPhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async Task FindSubsetMatch()
        {
            var expectedPhraseId = PhraseId<int>.From(1);
            var searchResult = await _searchEngine.Search("omer", LocalData);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == expectedPhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async Task FindMisspelledWord()
        {
            var searchResult = await _searchEngine.Search("Flenders", LocalData);
            var actual = searchResult.FirstOrDefault();
            Assert.Equal("Ned Flanders", actual.MatchingPhrase);
        }

        [Fact]
        public async Task FindWordWithTypo()
        {
            var searchResult = await _searchEngine.Search("Flnaders", LocalData);
            var actual = searchResult.FirstOrDefault();
            Assert.Equal("Ned Flanders", actual.MatchingPhrase);
        }

        [Fact]
        public async Task NotFindMatch()
        {
            var searchResult = await _searchEngine.Search("qwerty", LocalData);
            Assert.DoesNotContain(searchResult, x => x.MatchingPhrase == "qwerty");
        }
    }
}
