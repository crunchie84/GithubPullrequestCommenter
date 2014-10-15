GithubPullrequestCommenter
==========================

tool to append a given message to the given pull request in the given repo


Usage: pullrequest-commenter-cli options

```
   OPTION                            TYPE       POSITION   DESCRIPTION
   -Owner (-o)                       string*    0          Owner of repository to which we are going to send the message
   -Repository (-r)                  string*    1          Repository to which we are going to send the message
   -PullRequestId (-i)               integer*   2          The pull request / issue to which we are going to add this comment
   -PersonalGithubAccessToken (-t)   string*    3          The github personal access token, retrieved @https://help.github.com/articles/creating-an-access-token-for-command-line-use
   -Message (-m)                     string*    4          The commit message to append
```


# Source

https://github.com/crunchie84/GithubPullrequestCommenter