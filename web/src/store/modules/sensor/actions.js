import httpClient from '../../../common/HttpClient'
import { GET_SENSORS } from './actions.type'
import { SET_SENSORS } from './mutations.type'

const actions = {
    [GET_SENSORS](context) {
        return new Promise((resolve, reject) => {
            httpClient.get('/device/getsensors').then((payload) => {
                context.commit(SET_SENSORS, payload.data)
                resolve(payload)
            }).catch((err) => {
                reject(err)
            })
        })
    }
}

export default actions;