        [Test]
        public void SampleTest()
        {
            IManagedDriver driver = DriverPool.Instance.CreateReusableDriverFromLastRun();
            ITestObject testObject = TestObject.New(SearchInfo.New("label", "Start Date"), SearchInfo.New("input")).SetShortestDomDistanceDepth(5);
            var count = testObject.TryGetElementCount(2);
            var indexes = testObject.ElementIndexes;
            var allXPaths = testObject.AllLocators;
            var filteredXPaths = testObject.FilteredLocators;

            var countAfterFilters = testObject.FilterByEnabled().FilterByDisplayed().FilterByClickable().TryGetElementCount(2);
            var indexesAfterFilters = testObject.ElementIndexes;
            var allXPathsAfterFilters = testObject.AllLocators;
            var filteredXPathsAfterFilters = testObject.FilteredLocators;

            var countWithoutFilters = testObject.TryGetElementCount(2);
            var indexesWithoutFilters = testObject.ElementIndexes;
            var allXPathsWithoutFilters = testObject.AllLocators;
            var filteredXPathsWithoutFilters = testObject.FilteredLocators;

            var countAfterFiltersRemoved = testObject.RemoveAllFilters().TryGetElementCount(2);
            var indexesAfterFiltersRemoved = testObject.ElementIndexes;
            var allXPathsAfterFiltersRemoved = testObject.AllLocators;
            var filteredXPathsAfterFiltersRemoved = testObject.FilteredLocators;            
        }
        
        //Results:

            //count: 12
            //indexes: [0,1,2,3,4,5,6,7,8,9,10,11]
            //allXPaths: ["//div[label[contains(text(),\"Start Date\")]]/p-calendar/span/input", ...] --> 12 items
            //filteredXPaths: same as allXPaths

            //countAfterFilters: 3
            //indexesAfterFilters: [0,1,2]
            //allXPathsAfterFilters: ["//div[label[contains(text(),\"Start Date\")]]/p-calendar/span/input", ...] --> 12 items
            //filteredXPathsAfterFilters: ["//div[label[contains(text(),\"Start Date\")]]/p-calendar/span/input", ...] --> 3 items

            //countWithoutFilters: 3
            //indexesWithoutFilters: [0,1,2]
            //allXPathsWithoutFilters: ["//div[label[contains(text(),\"Start Date\")]]/p-calendar/span/input", ...] --> 12 items
            //filteredWithoutFilters: ["//div[label[contains(text(),\"Start Date\")]]/p-calendar/span/input", ...] --> 3 items

            //countAfterFiltersRemoved: 12
            //indexesAfterFiltersRemoved: [0,1,2,3,4,5,6,7,8,9,10,11]
            //allXPathsAfterFiltersRemoved: ["//div[label[contains(text(),\"Start Date\")]]/p-calendar/span/input", ...] --> 12 items
            //filteredAfterFiltersRemoved: same as allXPathsAfterFiltersRemoved
