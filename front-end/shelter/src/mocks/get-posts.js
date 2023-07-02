var names = ['dog1', 'dog2', 'dog3']

const getPosts = (num) => {
    let ret = []

    for(var i = 0; i < num; i++) {
        ret.push ({
            author: names[i % names.length],
            content: 'Text content'
        })
    }

    return ret

 }

 export default getPosts