namespace MyCompressionLib.Tests
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("aaabbcccdde", "a3b2c3d2e")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", "a30b")]
        [InlineData("abcdefghjklmnopqrstuvwxyz", "abcdefghjklmnopqrstuvwxyz")]
        [InlineData("abcdefghjjjklmnopqrstuvwxyz", "abcdefghj3klmnopqrstuvwxyz")]
        public void Compression_String_success(string input, string expected)
        {
            var result = MyCompression.Compression(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("a3b2c3d2e", "aaabbcccdde")]
        [InlineData("a30b", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaab")]
        [InlineData("abcdefghjklmnopqrstuvwxyz", "abcdefghjklmnopqrstuvwxyz")]
        [InlineData("abcdefghj3klmnopqrstuvwxyz", "abcdefghjjjklmnopqrstuvwxyz")]
        [InlineData("a30b5", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbb")]
        public void Decompression_String_success(string input, string expected)
        {
            var result = MyCompression.Decompression(input);
            Assert.Equal(expected, result);
        }
    }
}