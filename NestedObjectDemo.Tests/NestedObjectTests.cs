namespace NestedObjectDemo.Tests {
    [TestClass]
    public class NestedObjectTests {
        [TestMethod]
        public void TestOneLevelObject() {

            // Testing a one level object {a:b} with key a. Expected output: b
            string inputObject = "{\"a\":\"b\"}";
            string inputRequest = "a";
            string expectedOutput = "b";

            NestedObjectParser nestedObjectParser = new NestedObjectParser();
            string? parserOutput = nestedObjectParser.Parse(inputObject, inputRequest);

            Assert.AreEqual(parserOutput, expectedOutput);
        }

        [TestMethod]
        public void TestTwoLevelObject() {

            // Testing a two level object {a:{b:c}} with key a/b. Expected output: c
            string inputObject = "{\"a\":{\"b\":\"c\"}}";
            string inputRequest = "a/b";
            string expectedOutput = "c";

            NestedObjectParser nestedObjectParser = new NestedObjectParser();
            string? parserOutput = nestedObjectParser.Parse(inputObject, inputRequest);

            Assert.AreEqual(parserOutput, expectedOutput);
        }

        [TestMethod]
        public void TestThreeLevelObject() {

            // Testing a three level object {a:{b:{c:d}}} with key a/b/c. Expected output: d
            string inputObject = "{\"a\":{\"b\":{\"c\":\"d\"}}}";
            string inputRequest = "a/b/c";
            string expectedOutput = "d";

            NestedObjectParser nestedObjectParser = new NestedObjectParser();
            string? parserOutput = nestedObjectParser.Parse(inputObject, inputRequest);

            Assert.AreEqual(parserOutput, expectedOutput);
        }

        [TestMethod]
        public void TestFourLevelObject() {

            // Testing a four level object {a:{b:{c:{d:e}}}} with key a/b/c/d. Expected output: e
            string inputObject = "{\"a\":{\"b\":{\"c\":{\"d\":\"e\"}}}}";
            string inputRequest = "a/b/c/d";
            string expectedOutput = "e";

            NestedObjectParser nestedObjectParser = new NestedObjectParser();
            string? parserOutput = nestedObjectParser.Parse(inputObject, inputRequest);

            Assert.AreEqual(parserOutput, expectedOutput);
        }

        [TestMethod]
        public void TestInvalidJson() {

            // Testing that the correct exception is thrown for invalid Json. Passing "foo{baa}" as invalid Json. Expected output: JsonReaderException
            Exception? caughtException = null;
            try {
                NestedObjectParser nestedObjectParser = new NestedObjectParser();
                string? parserOutput = nestedObjectParser.Parse("foo{baa}", "a");

            } catch(Exception ex) {
                caughtException = ex;
            }

            Assert.IsInstanceOfType(caughtException, typeof(Newtonsoft.Json.JsonReaderException));

        }
    }
}