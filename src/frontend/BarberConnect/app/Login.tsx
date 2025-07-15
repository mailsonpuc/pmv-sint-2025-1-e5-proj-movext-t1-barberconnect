import * as React from 'react';
import { StyleSheet, View, Alert } from 'react-native';
import { Button, TextInput } from 'react-native-paper';
import { router } from 'expo-router';
import AsyncStorage from '@react-native-async-storage/async-storage'; // <- Importa AsyncStorage

const Login = () => {
  const [nome, setNome] = React.useState('');
  const [senha, setSenha] = React.useState('');

  const handleOk = async () => {
    try {
      const response = await fetch(
        'https://apibarbearia-eahzdfefbpgwbah5.brazilsouth-01.azurewebsites.net/api/Auth/login',
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            userName: nome, // <- deve ser "userName" com N maiúsculo
            password: senha,
          }),
        }
      );

      if (response.ok) {
        const data = await response.json();

        // Armazena os tokens no AsyncStorage
        await AsyncStorage.setItem('accessToken', data.token);
        await AsyncStorage.setItem('refreshToken', data.refreshToken);

        Alert.alert('Sucesso', 'Usuário logado com sucesso!', [
          {
            text: 'OK',
            onPress: () => router.replace('/BotaoNavegacao'),
          },
        ]);
      } else {
        const error = await response.json();
        Alert.alert('Erro', error.message || 'Não foi possível logar.');
      }
    } catch (err) {
      console.error('Erro na requisição:', err);
      Alert.alert('Erro', 'Erro de conexão com o servidor.');
    }
  };

  return (
    <View style={styles.container}>
      <TextInput
        label="Nome de usuário"
        value={nome}
        onChangeText={setNome}
        style={styles.input}
        autoCapitalize="none"
      />

      <TextInput
        label="Senha"
        value={senha}
        onChangeText={setSenha}
        secureTextEntry
        style={styles.input}
      />

      <Button mode="contained" onPress={handleOk}>
        OK
      </Button>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 16,
    justifyContent: 'center',
  },
  input: {
    marginBottom: 16,
  },
});

export default Login;
