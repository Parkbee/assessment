# ParkBee SSG&CMS Challenge

### Introduction

A static site is a compiled website, meaning it is comprised of just the HTML, CSS and JavaScript required to run the page. All pages are statically built ahead of time through some kind of static site build tool, or generator. The content is only updated when the website is “rebuilt.” Static sites offer many advantages over their dynamic site counterparts, including speed, security, and ease of maintenance.

SSGs offer a valuable compromise between hand-coded static sites and full CMS capabilities – while retaining the both their benefits.With SSGs, developers e ssentially write dynamically and publish statically.

A static site generator is essentially a set of tools for building static websites based on a set of input files. This differs hugely from a typical CMS site using something like Wordpress or Drupal, which have to execute numerous database queries to render a page for every single user. This is a reason why Wordpress sites with multiple plugins begin to deteriorate in performance, since each plugin will have to execute requests of their own - process it - and then have the pages load them dynamically. With SSGs, on the other hand, speed and performance is greatly improved because all the server needs to do is return a file – not construct a page to be displayed for every request sent by each client. In short, the same content doesn’t need to be constructed multiple times for every visitor, but can be served almost instantly from a "cached" version.

### Requirements

We have intentionally kept this assignment very stricted, you'll have to create a simple blog post application with SSG support, here are the minimum requirements:

- Use Angular, Scully and a CMS of you choice.
- Supports all SSG features
- Your application should have two routes:
  -   `/posts` - List of all available posts.
  -   `p/${postIdentfier}` - Page with the post content

### What we will be looking for

- Code structure and organization
- The project should have a `README` with all information that you think its relevant for understanding and running the project.
- Add/Delete/Edit contents
- You can create the design for the pages, we're not expecting super well designed pages but the pages should be fully responsive and we'll take into consideration the CSS code.
