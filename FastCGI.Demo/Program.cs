using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FastCGI;

namespace FastCGI.Demo
{
	class Program
	{
		static void Main ( string[] args )
		{
			// Create a new FCGIApplication, will accept FastCGI requests
			var app = new FCGIApplication();

			// Handle requests by responding with a 'Hello World' message
			app.OnRequestReceived += ( sender, request ) =>
			{
				StringBuilder responseString = new StringBuilder ();
				//responseString.AppendLine ( "HTTP/1.1" );
				responseString.AppendLine ( "Status: 200 OK" );
				responseString.AppendLine ( "Content-Type: text/html" );
				//responseString.AppendLine("charset=utf-8");
				//responseString.AppendLine();
				responseString.AppendLine ();
				responseString.AppendLine ( "Hello World!" );

				request.WriteResponseASCII ( responseString.ToString () );
				request.Close ();
			};

			// Start listening on port 19000
			app.Run ( 19000 );
		}
	}
}
