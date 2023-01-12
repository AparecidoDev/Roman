import React, { Component } from 'react';
import { Image, StyleSheet, Text, TextInput, TouchableOpacity, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { Picker } from '@react-native-picker/picker';

import api from '../services/api';

export default class ProjectRegister extends Component {
    constructor(props) {
        super(props);
        this.state = {
            NomeProjeto: '',
            IdTema: 0,
            Descricao: '',
            isLoading: false
        }
    }

    logout = async () => {
        try {
            await AsyncStorage.removeItem('userToken');
            this.props.navigation.navigate('Login');
        } catch (error) {
            console.warn(error);
        }
    };

    atualizaTema = (itemValue) => {
        this.setState({ IdTema: itemValue })
    }

    // função para cadastrar um projeto
    postProjects = async () => {

        // requisição em andamento
        this.setState({ isLoading: true });

        // corpo da requisição
        let project = {
            NomeProjeto: this.state.NomeProjeto,
            IdTema: this.state.IdTema,
            Descricao: this.state.Descricao,
            // NomeTema: this.state.NomeTema
        }

        // constante para armazenar o valor do token
        const valorToken = await AsyncStorage.getItem('userToken');
        console.log(project)

        // chamada para api - método cadastrar e o corpo da requisição
        await api.post('/projeto', project, {
            headers: {
                'Authorization': 'Bearer ' + valorToken
            }
        })

            // verifica a resposta da requisição
            .then(resposta => {

                // caso seja 201
                if (resposta.status === 201) {

                    // retorna uma mensagem 
                    console.warn('Projeto cadastrado !')


                    // requisição finalizada
                    this.setState({ isLoading: false })
                }
            })

            // caso ocorra um erro
            .catch(erro => {

                // exibe uma mensagem 
                console.warn(erro)

                // requisição finalizada
                this.setState({ isLoading: false })
            })

    };

    // renderiza a tela
    render() {

        return (

            <View style={styles.main}>

                {/* Header */}
                <View style={styles.mainHeader}>
                    <View style={styles.mainHeaderRow}>
                        <Text style={styles.mainHeaderText}>Cadastro</Text>
                    </View>

                    <View style={styles.mainHeaderLine} />

                    <TouchableOpacity
                        onPress={this.logout}
                    >
                        <Image
                            source={require('../../assets/img/logout1.png')}
                            style={styles.tabBarIcon}
                        />
                    </TouchableOpacity>



                </View>



                {/* Formulário para o cadastro e buttom */}
                <View style={styles.mainHeader}>

                    <TextInput
                        style={styles.inputRegister}
                        placeholder='Título'
                        placeholderTextColor='#B338F5'
                        keyboardType='text'
                        onChangeText={NomeProjeto => this.setState({ NomeProjeto })}
                    />

                    <Picker
                        style={styles.inputRegister}
                        selectedValue={this.state.NomeTema}
                        onValueChange={(itemValue, itemIndex) =>
                            this.atualizaTema(itemValue)
                        }>

                        <Picker.Item label="Selecione o Tema" value="" />
                        <Picker.Item label="Gestão" value="1" />
                        <Picker.Item label="HQ's" value="2" />
                    </Picker>


                    <TextInput
                        style={styles.inputRegister}
                        placeholder='Descrição'
                        placeholderTextColor='#B338F5'
                        keyboardType='text'
                        onChangeText={Descricao => this.setState({ Descricao })}
                    />



                    <TouchableOpacity
                        style={styles.btnRegister}
                        onPress={this.postProjects}
                    >
                        <Image
                            source={require('../../assets/img/cadastro.png')}
                            style={styles.imgBtnRegister}
                        />

                    </TouchableOpacity>

                </View>

            </View>

        );
    }
}

const styles = StyleSheet.create({

    textProfessor: {
        color: '#B338F5',
        paddingTop: 15,
        fontFamily: 'Open Sans',
        fontSize: 16
    },

    main: {
        flex: 1,
        backgroundColor: '#FFF'
    },

    // cabeçalho
    mainHeader: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        // backgroundColor: 'blue',
        top: -100

    },

    mainHeaderRow: {
        flexDirection: 'row'
    },

    tabBarIcon: {
        width: 25,
        height: 25,
        marginTop: 15,
        tintColor: '#B338F5'
    },

    imgBtnRegister: {
        width: 20,
        height: 20,

    },

    // imagem do cabeçalho
    mainHeaderImg: {
        width: 22,
        height: 22,
        tintColor: '#ccc',
        marginRight: -5,
        marginTop: -12
    },
    // texto do cabeçalho
    mainHeaderText: {
        fontSize: 16,
        letterSpacing: 2,
        color: '#B338F5',
        fontFamily: 'Open Sans'
    },
    // linha de separação do cabeçalho
    mainHeaderLine: {
        width: 180,
        paddingTop: 10,
        borderBottomColor: '#B338F5',
        borderBottomWidth: 1,

    },


    // conteúdo do body
    mainBody: {
        flex: 4,
        // backgroundColor: 'red'
    },
    // conteúdo da lista
    mainBodyContent: {
        paddingTop: 30,
        paddingRight: 50,
        paddingLeft: 50
    },
    flatItemRow: {
        flexDirection: 'row',
        borderBottomWidth: 1,
        borderBottomColor: '#ccc',
        marginTop: 30
    },
    flatItemContainer: {
        flex: 1
    },
    flatItemTitle: {
        fontSize: 16,
        color: 'black',
        fontFamily: 'Open Sans Light'
    },
    flatItemInfo: {
        fontSize: 12,
        // #RRGGBB
        // #RGB
        color: '#999',
        lineHeight: 20
    },
    flatItemImg: {
        justifyContent: 'center'
    },
    flatItemImgIcon: {
        width: 26,
        height: 26,
        tintColor: '#B727FF'
    },

    inputRegister: {
        width: 200,
        marginBottom: 40,
        fontSize: 16,
        color: '#B338F5',
        borderColor: '#B338F5',
        borderBottomWidth: 1,
        fontFamily: 'Open Sans'
    },

    btnRegister: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 38,
        width: 200,
        backgroundColor: '#561B75',
        borderColor: '#8D2DC2',
        borderWidth: 1,
        borderRadius: 4,

    },

    btnLoginRegister: {
        fontSize: 12,
        color: '#FFF',
        letterSpacing: 6,
        textTransform: 'uppercase'
    }

});