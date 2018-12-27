FROM jetbrains/teamcity-agent:2017.1.2

RUN curl -L https://github.com/docker/compose/releases/download/1.13.0/docker-compose-`uname -s`-`uname -m` > /usr/local/bin/docker-compose \
    && chmod +x /usr/local/bin/docker-compose

RUN apt-get update
RUN apt-get install -y python
RUN apt-get install -y python-pip
RUN pip install --upgrade awscli==1.14.5 s3cmd==2.0.1 python-magic
RUN apt-get remove -y python-pip
RUN apt-get remove -y python

ENV AWS_ACCESS_KEY_ID=AKIAJJRB5CWSSUWNPG2A
ENV AWS_SECRET_ACCESS_KEY=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
ENV AWS_DEFAULT_REGION=eu-west-2
# VOLUME /root/.aws
# VOLUME /project
# WORKDIR /project
# RUN export AWS_PROFILE=bless-aws
RUN aws ecr get-login --no-include-email
RUN aws --version
# RUN eval $(aws ecr get-login –profile bless-admin –no-include-email)
RUN apt-get clean all
#     groff \
#     less \
#     mailcap \
#     && \
#     pip install --upgrade awscli==1.14.5 s3cmd==2.0.1 python-magic && \
# apt-get -v --purge del py-pip && \
# rm /var/cache/apt/*

# VOLUME /project
# WORKDIR /project
# ENTRYPOINT ["aws"]