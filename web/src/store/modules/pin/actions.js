import httpClient from '../../../common/HttpClient'
import { GET_AVAILABLE_PINS } from './actions.type'
import { SET_AVAILABLE_PINS } from './mutations.type'

const actions = {
    [GET_AVAILABLE_PINS](context, payload) {
        return new Promise((resolve, reject) => {
            httpClient.get(`/device/availablepins/${payload.Id}`).then((payload) => {
                context.commit(SET_AVAILABLE_PINS, payload.data);
                resolve(payload)
            }).catch((err) => {
                reject(err)
            })
        })
    }
}

export default actions;