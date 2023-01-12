import React, { Component } from 'react';
import { Image, StyleSheet, Text, TextInput, TouchableOpacity, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: ''
        }
    }

    login = async () => {

        const response = await api.post('/login', {

            email: this.state.email,
            senha: this.state.senha

        })

        const token = response.data.token

        await AsyncStorage.setItem('userToken', token)

        this.props.navigation.navigate('Main')
    }

    render() {

        return (

            <View style={styles.contentLogin}>


                <View style={styles.main}>


                    <Text style={styles.title}>Roman</Text>

                    <Image
                        source={require('../../assets/img/login1.png')}
                        style={styles.imgUser}
                    />

                    <TextInput
                        style={styles.inputLogin}
                        placeholder='username'
                        placeholderTextColor='#FFF'
                        keyboardType='email-address'
                        onChangeText={email => this.setState({ email })}
                    />

                    <TextInput
                        style={styles.inputLogin}
                        placeholder='password'
                        placeholderTextColor='#FFF'
                        secureTextEntry={true}
                        onChangeText={senha => this.setState({ senha })}
                    />

                    <TouchableOpacity
                        style={styles.btnLogin}
                        onPress={this.login}
                    >
                        <Image
                            source={require('../../assets/img/login.png')}
                            style={styles.imgLogin}
                        />

                    </TouchableOpacity>

                </View>

            </View>
        )
    }
}


const styles = StyleSheet.create({

    contentLogin: {
        backgroundColor: '#CF83F7',
        height: '100%',
        fontFamily: ''
    },

    main: {
        backgroundColor: '#8D2DC2',
        width: '80%',
        height: '60%',
        marginTop: '40%',
        marginLeft: '10%',
        justifyContent: 'center',
        alignItems: 'center',
        shadowOffset: { width: 10, height: 10, },
        shadowColor: '#8D2DC2',
        shadowOpacity: .5,
    },

    title: {
        color: '#FFF',
        fontFamily: 'Open Sans',
        fontSize: 35,
        marginBottom: 30,
        textTransform: 'uppercase',
        fontWeight: 800
    },

    imgUser: {
        width: 60,
        height: 60,
        marginBottom: 50
    },

    imgLogin: {
        width: 30,
        height: 30,
        tintColor: '#8D2DC2'
    },

    inputLogin: {
        width: 200,
        marginBottom: 40,
        fontSize: 16,
        color: '#FFF',
        borderColor: '#FFF',
        borderBottomWidth: 2
    },

    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 38,
        width: 200,
        backgroundColor: '#FFF',
        borderColor: '#FFF',
        borderWidth: 1,
        borderRadius: 4,
    },

    btnLoginText: {
        fontSize: 12,
        color: '#8D2DC2',
        letterSpacing: 6,
        textTransform: 'uppercase'
    }

})