 [HttpPost]
        [EnableCors("http://localhost:55912", // Origin
             null,                     // Request headers
             "GET",                    // HTTP methods
             "bar",                    // Response headers
             SupportsCredentials = true  // Allow credentials )]
        public string Post([FromBody]Url value)
        {
            string ourUrl = value.UrlString;
            string output = "";
            // now we'll try to find this in our guide types

            Guide ourGuide = new Guide();

            output = ourGuide.findGuide(ourUrl);
            return "{ result: " + output + "}"; 
        }
