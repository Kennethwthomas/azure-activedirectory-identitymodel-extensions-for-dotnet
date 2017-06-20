//------------------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using System;
using Microsoft.IdentityModel.Xml;
using static Microsoft.IdentityModel.Logging.LogHelper;

namespace Microsoft.IdentityModel.Tokens.Saml2
{
    /// <summary>
    /// Represents the AuthnStatement element specified in [Saml2Core, 2.7.2]. 
    /// </summary>
    public class Saml2AuthenticationStatement : Saml2Statement
    {
        private Saml2AuthenticationContext _authnContext;
        private DateTime _authnInstant;
        private string _sessionIndex;
        private DateTime? _sessionNotOnOrAfter;

        /// <summary>
        /// Creates a Saml2AuthenticationStatement.
        /// </summary>
        /// <param name="authenticationContext">The authentication context of this statement.</param>
        public Saml2AuthenticationStatement(Saml2AuthenticationContext authenticationContext)
            : this(authenticationContext, DateTime.UtcNow)
        { }

        /// <summary>
        /// Creates an instance of Saml2AuthenticationContext.
        /// </summary>
        /// <param name="authenticationContext">The authentication context of this statement.</param>
        /// <param name="authenticationInstant">The time of the authentication.</param>
        public Saml2AuthenticationStatement(Saml2AuthenticationContext authenticationContext, DateTime authenticationInstant)
        {
            AuthenticationContext = authenticationContext;
            AuthenticationInstant = authenticationInstant;
        }

        /// <summary>
        /// Gets or sets the <see cref="Saml2AuthenticationContext"/> used by the authenticating authority up to and including 
        /// the authentication event that yielded this statement. [Saml2Core, 2.7.2]
        /// </summary>
        public Saml2AuthenticationContext AuthenticationContext
        {
            get { return _authnContext; }
            set { _authnContext = value ?? throw LogArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Gets or sets the time at which the authentication took place. [Saml2Core, 2.7.2]
        /// </summary>
        public DateTime AuthenticationInstant
        {
            get { return _authnInstant; }
            set { _authnInstant = DateTimeUtil.ToUniversalTime(value); }
        }

        /// <summary>
        /// Gets or sets the index of a particular session between the principal 
        /// identified by the subject and the authenticating authority. [Saml2Core, 2.7.2]
        /// </summary>
        public string SessionIndex
        {
            get { return _sessionIndex; }
            set { _sessionIndex = XmlUtil.NormalizeEmptyString(value); }
        }

        /// <summary>
        /// Gets or sets the time instant at which the session between the principal 
        /// identified by the subject and the SAML authority issuing this statement
        /// must be considered ended. [Saml2Core, 2.7.2]
        /// </summary>
        public DateTime? SessionNotOnOrAfter
        {
            get { return _sessionNotOnOrAfter; }
            set { _sessionNotOnOrAfter = DateTimeUtil.ToUniversalTime(value); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Saml2SubjectLocality"/> which contains the DNS domain name and IP address for the system from which 
        /// the assertion subject was authenticated. [Saml2Core, 2.7.2]
        /// </summary>
        public Saml2SubjectLocality SubjectLocality
        {
            get; set;
        }
    }
}
