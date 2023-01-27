import requests

def get_metadata(url):
    try:
        response = requests.get(url, timeout=1)
        if response.status_code == 200:
            return response.text
    except requests.exceptions.RequestException as e:
        pass

aws_metadata = get_metadata("http://169.254.169.254/latest/meta-data/")
if aws_metadata:
    print("Running on AWS, metadata: " + aws_metadata)
else:
    azure_metadata = get_metadata("http://169.254.169.254/metadata/instance?api-version=2020-09-01")
    if azure_metadata:
        print("Running on Azure, metadata: " + azure_metadata)
    else:
        gcp_metadata = get_metadata("http://metadata.google.internal/computeMetadata/v1/")
        if gcp_metadata:
            print("Running on GCP, metadata: " + gcp_metadata)
