You will need compile the project and then install.
### Dependencies ###
Install dependencies for Ubuntu and Debian:
```
 sudo aptitude install autotools-dev autoconf mono automake1.10 mono-runtime mono-gmcs
```

### Compile and Install ###
```
 wget http://monobenchmark.googlecode.com/files/monobenchmark-0.1.tar.gz
 cd monobenchmark && ./configure && make && make install
```