import requests

# PyTest script for automated testing
# To test use "pytest --url 'https://localhost/someapipath' " and pytest should call both a 
# GET and POST to the URL to ensure successful status is returned along with PNG content.


def test_get(url):
    # Additional querystring required for GET
    querystring = '?text=testApiSlot&size=150'
    url = url + querystring

    # Get
    respGet = requests.get(url)

    print (respGet.text)

    # Check the status code
    assert respGet.status_code == 200

    # Check the content type to ensure its returning a PNG
    assert respGet.headers['content-type'] == 'image/png'




def test_post(url):
    # Additional headers and payload required for POST
    headers = {'Content-Type': 'text/plain'}
    payload = 'Some Test Content to be encoded Goes here'

    # Post  
    respPost = requests.post(url, headers=headers, data=payload)

    print (respPost.text)

    # Check the status code
    assert respPost.status_code == 200

    # Check the content type to ensure its returning a PNG
    assert respPost.headers['content-type'] == 'image/png'



