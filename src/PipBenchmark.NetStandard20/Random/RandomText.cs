using System;
using System.Linq;
using System.Text;

namespace PipBenchmark.Utilities.Random
{
	/// <summary>
	/// Random generator for various text values like names, addresses or phone numbers.
	/// </summary>
	/// <example>
	/// <code>
	/// var value1 = RandomText.Name();     // Possible result: "Sergio"
	/// var value2 = RandomText.Verb();      // Possible result: "Run"
	/// var value3 = RandomText.Text(50);    // Possible result: "Run jorge. Red high scream?"
	/// </code>
	/// </example>
	public class RandomText
	{
		private static readonly string[] _namePrefixes = new string[] { "Dr.", "Mr.", "Mrs" };
		private static readonly string[] _nameSuffixes = new string[] { "Jr.", "Sr.", "II", "III" };
		private static readonly string[] _firstNames = new string[] {
			"John", "Bill", "Andrew", "Nick", "Pamela", "Bela", "Sergio", "George", "Hurry", "Cecilia", "Vesta", "Terry", "Patrick"
		};
		private static readonly string[] _lastNames = new string[] {
			"Doe", "Smith", "Johns", "Gates", "Carmack", "Zontak", "Clinton", "Adams", "First", "Lopez", "Due", "White", "Black"
		};
		private static readonly string[] _colors = new string[] {
			"Black", "White", "Red", "Blue", "Green", "Yellow", "Purple", "Grey", "Magenta", "Cian"
		};
		private static readonly string[] _stuffs = new string[] {
			"Game", "Ball", "Home", "Board", "Car", "Plane", "Hotel", "Wine", "Pants", "Boots", "Table", "Chair"
		};
		private static readonly string[] _adjectives = new string[] {
			"Large", "Small", "High", "Low", "Certain", "Fuzzy", "Modern", "Faster", "Slower"
		};
		private static readonly string[] _verbs = new string[] {
			"Run", "Stay", "Breeze", "Fly", "Lay", "Write", "Draw", "Scream"
		};

		private static readonly string[] _allWords = _firstNames.Concat(_lastNames).Concat(_colors).Concat(_stuffs).Concat(_adjectives)
			.Concat(_verbs).ToArray();

		/// <summary>
		/// Generates a random color name. The result value is capitalized.
		/// </summary>
		/// <returns>a random color name.</returns>
		public static string Color()
		{
			return RandomString.Pick(_colors);
		}

		/// <summary>
		/// Generates a random noun. The result value is capitalized.
		/// </summary>
		/// <returns>a random noun.</returns>
		public static string Stuff()
		{
			return RandomString.Pick(_stuffs);
		}

		/// <summary>
		/// Generates a random adjective. The result value is capitalized.
		/// </summary>
		/// <returns>a random adjective.</returns>
		public static string Adjective()
		{
			return RandomString.Pick(_adjectives);
		}

		/// <summary>
		/// Generates a random verb. The result value is capitalized.
		/// </summary>
		/// <returns>a random verb.</returns>
		public static string Verb()
		{
			return RandomString.Pick(_verbs);
		}

		/// <summary>
		/// Generates a random phrase which consists of few words separated by spaces.
		/// The first word is capitalized, others are not.
		/// </summary>
		/// <param name="size">the size of phrase</param>
		/// <returns>a random phrase.</returns>
		public static string Phrase(int size)
		{
			return Phrase(size, size);
		}

		/// <summary>
		/// Generates a random phrase which consists of few words separated by spaces.
		/// The first word is capitalized, others are not.
		/// </summary>
		/// <param name="minSize">(optional) minimum string length.</param>
		/// <param name="maxSize">maximum string length.</param>
		/// <returns>a random phrase.</returns>
		public static string Phrase(int minSize, int maxSize)
		{
			maxSize = Math.Max(minSize, maxSize);
			int size = RandomInteger.NextInteger(minSize, maxSize);
			if (size <= 0) return "";

			StringBuilder result = new StringBuilder();
			result.Append(RandomString.Pick(_allWords));
			while (result.Length < size)
			{
				result.Append(" ").Append(RandomString.Pick(_allWords).ToLower());
			}

			return result.ToString();
		}

		/// <summary>
		/// Generates a random person's name which has the following structure
		/// optional prefix - first name - second name - optional suffix
		/// </summary>
		/// <returns>a random name.</returns>
		public static string Name()
		{
			StringBuilder result = new StringBuilder();

			if (RandomBoolean.Chance(3, 5))
				result.Append(RandomString.Pick(_namePrefixes)).Append(" ");

			result.Append(RandomString.Pick(_firstNames))
				.Append(" ")
				.Append(RandomString.Pick(_lastNames));

			if (RandomBoolean.Chance(5, 10))
				result.Append(" ").Append(RandomString.Pick(_nameSuffixes));

			return result.ToString();
		}

		/// <summary>
		/// Generates a random word from available first names, last names, colors, stuffs, adjectives, or verbs.
		/// </summary>
		/// <returns>a random word.</returns>
		public static string Word()
		{
			return RandomString.Pick(_allWords);
		}

		/// <summary>
		/// Generates a random text that consists of random number of random words separated by spaces.
		/// </summary>
		/// <param name="min">(optional) a minimum number of words.</param>
		/// <param name="max">a maximum number of words.</param>
		/// <returns>a random text.</returns>
		public static string Words(int min, int max)
		{
			StringBuilder result = new StringBuilder();

			int count = RandomInteger.NextInteger(min, max);
			for (int i = 0; i < count; i++)
				result.Append(RandomString.Pick(_allWords));

			return result.ToString();
		}

		/// <summary>
		/// Generates a random phone number. The phone number has the format: (XXX) XXX-YYYY
		/// </summary>
		/// <returns>a random phone number.</returns>
		public static string Phone()
		{
			StringBuilder result = new StringBuilder();

			result.Append("(")
				.Append(RandomInteger.NextInteger(111, 999))
				.Append(") ")
				.Append(RandomInteger.NextInteger(111, 999))
				.Append("-")
				.Append(RandomInteger.NextInteger(0, 9999));

			return result.ToString();
		}

		/// <summary>
		/// Generates a random email address.
		/// </summary>
		/// <returns>a random email address.</returns>
		public static string Email()
		{
			return Words(2, 6) + "@" + Words(1, 3) + ".com";
		}

		/// <summary>
		/// Generates a random text, consisting of first names, last names, colors, stuffs, adjectives, verbs, and punctuation marks.
		/// </summary>
		/// <param name="size">the size of text.</param>
		/// <returns>a random text.</returns>
		public static string Text(int size)
		{
			return Text(size, size);
		}

		/// <summary>
		/// Generates a random text, consisting of first names, last names, colors, stuffs, adjectives, verbs, and punctuation marks.
		/// </summary>
		/// <param name="minSize">minimum amount of words to generate. Text will contain 'minSize' words if 'maxSize' is omitted.</param>
		/// <param name="maxSize">(optional) maximum amount of words to generate.</param>
		/// <returns>a random text.</returns>
		public static string Text(int minSize, int maxSize)
		{
			maxSize = Math.Max(minSize, maxSize);
			int size = RandomInteger.NextInteger(minSize, maxSize);

			StringBuilder result = new StringBuilder();
			result.Append(RandomString.Pick(_allWords));

			while (result.Length < size)
			{
				String next = RandomString.Pick(_allWords);
				if (RandomBoolean.Chance(4, 6))
					next = " " + next.ToLower();
				else if (RandomBoolean.Chance(2, 5))
					next = RandomString.Pick(":,-") + next.ToLower();
				else if (RandomBoolean.Chance(3, 5))
					next = RandomString.Pick(":,-") + " " + next.ToLower();
				else
					next = RandomString.Pick(".!?") + " " + next;

				result.Append(next);
			}

			return result.ToString();
		}
	}
}
