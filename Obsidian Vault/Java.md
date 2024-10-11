- Can use `Maven local repository` replace for `system path` in POM file
  Example:  (navigate to .m2/com/.... to remove old)
```
mvn install:install-file -Dfile=ezyfox-server.jar -DgroupId=com.tvd12 -DartifactId=ezyfox-server -Dversion=1.2.8.1 -Dpackaging=jar
```