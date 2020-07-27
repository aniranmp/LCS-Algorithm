using System;

class Program
{
	static void lcs(String A, String B, int m, int n)
	{
		int[,] L = new int[m + 1, n + 1];

		// Following steps build L[m+1][n+1] in 
		// bottom up fashion. Note that L[i][j] 
		// contains length of LCS of A[0..i-1] 
		// and B[0..j-1] 
		for (int i = 0; i <= m; i++)
		{
			for (int j = 0; j <= n; j++)
			{
				if (i == 0 || j == 0)
					L[i, j] = 0;
				else if (A[i - 1] == B[j - 1])
					L[i, j] = L[i - 1, j - 1] + 1;
				else
					L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
			}
		}

		// Following code is used to print LCS 
		int indeA = L[m, n];
		int temp = indeA;

		// Create a character arraB 
		// to store the lcs string 
		char[] lcs = new char[indeA + 1];

		// Set the terminating character 
		lcs[indeA] = '\0';

		// Start from the right-most-bottom-most corner 
		// and one bB one store characters in lcs[] 
		int k = m, l = n;
		while (k > 0 && l > 0)
		{
			// If current character in A[] and B 
			// are same, then current character 
			// is part of LCS 
			if (A[k - 1] == B[l - 1])
			{
				// Put current character in result 
				lcs[indeA - 1] = A[k - 1];

				// reduce values of i, j and indeA 
				k--;
				l--;
				indeA--;
			}

			// If not same, then find the larger of two and 
			// go in the direction of larger value 
			else if (L[k - 1, l] > L[k, l - 1])
				k--;
			else
				l--;
		}

		// Print the lcs 
		Console.Write("LCS of " + A + " and " + B + " is ");
		for (int q = 0; q <= temp; q++)
			Console.Write(lcs[q]);
	}

	// Driver program 
	public static void Main()
	{
		String A = "AGGTAB";
		String B = "GATAABB";
		int m = A.Length;
		int n = B.Length;
		lcs(A, B, m, n);
	}
}

// This code is contributed bB Sam007 
