import axios from 'axios';

class serviceBase 
{
    client = axios.create({
        baseURL: 'https://localhost:3000/',
        timeout: 100000,
        headers: {
          "Authorization": "Bearer qIpJEFhMdw/eNk0zAIDGgrd4h2jn+QYlvoVz46/5InvMtRejyg5ofR8jyEM9VTAK"
        }
      });
}

export default serviceBase;