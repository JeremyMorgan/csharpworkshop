public HttpResponseMessage Post([FromBody] PostObject ourPostObject)
        {
            try
            {
               // Debug.WriteLine(ourPostObject.testValue);
                // post object
                Mailer ourMailer = new Mailer();
                try
                {
                    ourMailer.sendEmail(ourPostObject.recipient, ourPostObject.subject, ourPostObject.message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

                ourPostObject.status = "SENT";

                return Request.CreateResponse(HttpStatusCode.OK, ourPostObject);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
