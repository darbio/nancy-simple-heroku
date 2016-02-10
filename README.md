# A simple C# app that deploys to Heroku in one step

This repo contains a bare-bones, self-hosting Nancy app prepared for
deployment on Heroku. All you have to do to get a C# web app deployed on
Heroku is:

```shell
$ rake init
```

All of the heavy lifting was done by [Ben Hall](https://github.com/BenHall); the
goal of this fork is simply to collect and document Ben's hard work to
make it even easier to create simple C# apps on Heroku.

### First Steps

First off, you need to [get
Mono](http://www.go-mono.com/mono-downloads/download.html), create a
[Heroku account](https://api.heroku.com/signup), and install the [Heroku toolbelt](https://toolbelt.heroku.com/)
if you haven't already. Then, to create a new Heroku app, deploy your
app to Heroku, and open it in your browser, simply do:

```shell
$ rake init
```

You should only run `rake init` once.  When Heroku creates a new app, it
assigns a unique hostname to your app–something like
`stark-hollows-8350.herokuapp.com`. `rake init` reads this
hostname and saves it as a Heroku environment variable,
which the Nancy app reads to bind to the correct URL. If you ever change
your Heroku hostname, remember to update `HOST`:

```shell
$ heroku config:add HOST=<your new hostname>
```

N.B. For Heroku, the HOST should be set to `localhost`

### Building

```shell
$ rake build
```

### Running your app locally

```shell
$ rake stage # or just `rake`
```

### Deploying to Heroku

This is merely a shortcut for `git push heroku master`:

```shell
$ rake deploy
```
## Rationale

I'm a developer who uses OS X and loves how easy Heroku makes web app
deployment. Heroku's path of least resistance is to use Rails or Node to
create your web app, and while I adore CoffeeScript and have some
experience writing web apps with Rails and Express, sometimes I want
to write my web app in a statically-typed language.

I'm a huge fan of the Mono project, and want to run web apps on Mono,
but I've always found .NET web app configuration and deployment overly
complicated, especially since I don't use Windows or Visual Studio as my
main development environment, and I want something 'lighter' than
ASP.NET for simple web services.

[Nancy](http://nancyfx.org/) is a Sinatra-esque DSL in C# for creating
web apps, and Ben Hall created a Heroku buildpack for Mono and blogged
about running Nancy on Heroku about a year ago. I've collected bits of
information from Ben's blog posts and added a `Rakefile` to make the
process of deploying this tiny app a little easier.

Enjoy!
