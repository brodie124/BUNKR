# BUNKR
> This project is a work in progress and is nowhere near completion.
> 
> The below is a description of how this project is intended to be, not how it currently is.

A centralised solution for requesting, renewing and distributing 
Let's Encrypt SSL certificates to multiple remotes.

This project aims to solve a niche problem; there are plenty of solutions to hosting various sections
of a website across different servers using Let's Encrypt certificates. For example, you may have:
- ACME clients on each remote managing the subdomains they have responsibility for
- Automated FTP uploads to transfer SSL certificates

However, solutions such as those mentioned above do not provide a mechanism for SSL certificate management that 
is both centralised and secure.

BUNKR aims to solve this by:
- Encrypting SSL certificates at-rest and in-transit
- Providing an easy-to-use access control system to limit the certificates each remote can access
- Automatically renewing and distributing SSL certificates as necessary
- Providing an easy way to register additional remotes
- Allowing new domains to be setup within a few simple clicks, including:
  - Requesting the new certificate from Let's Encrypt
  - Amending NGINX / Apache2 web server configuration files
- Supporting wildcard certificates with manual and automatic registrar DNS updates

## Architecture
![BUNKR Architecture](/Docs/Images/Architecture.png)

BUNKR is split into two components, `BUNKR.Primary` and `BUNKR.Secondary`.

`BUNKR.Primary` -> the brains of the operation, handles all SSL certificate management, communication with Let's Encrypt
and updating DNS entries where necessary.

`BUNKR.Secondary` -> an agent running on each remote, responsible for forwarding any ACME HTTP-01 challenge requests, as well
as receiving SSL certificates from the `BUNKR.Primary` and updating them as appropriate for the running HTTP web server.
